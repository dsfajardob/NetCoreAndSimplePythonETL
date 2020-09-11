import pandas as pd

def menu():
    options = {1:'.xlsx' ,2: '.csv'}
    option = 0
    try:
        option = int(input(" What kind of files will be read (Type the number) \n 1. xlsx\n 2. cvs\n another number to exit\n"))
    except:
        print("Oops it seems that you dont enter a number")
        return

    if option in options:
       return options[option]
    else:
        return False

def readNamesAndColums(extension,files):
    names  = {}
    readedFiles = 0
    while readedFiles < files:
        name = input("Please type the name of the {} file to read\n".format(readedFiles+1)) + extension
        if name not in names:
            names[name] = []
        else:
            print("You already write that file!")
        while True:
            option = input("Want to read a column Y/N\n")
            if option == 'N':
                break
            column = input('please write the name of the column to read\n')
            names[name].append(column)
        readedFiles = readedFiles + 1
    return names

def DataFrames(files,option):
    dataFrames = []
    i = 0
    if option == '.xlsx':
        for key in files:
           dataFrames.append(pd.read_excel(key, usecols=files[key]))
    else:
        for key in files:
           dataFrames.append(pd.read_csv(key, usecols=files[key]))
    #mergeColum = input('Please enter the name of the colum to join the two files\n')
    mergeColum = 'COD PRODUCTO'
    data = pd.merge(dataFrames[0], dataFrames[1], how='inner' )
    data = data.drop_duplicates(subset=[mergeColum])
    return data


def operations(data):
    #col1 = input('please enter the 1 colum to operate\n')
    #col2 = input('please enter the 2 colum to operate\n')
    #operation = input('please enter the option of the operation 1.Sum \n2.Subtraction \n3.Mean \n')
    col1 = 'UNIDADES'
    col2 = 'COD TQ'
    operation = '3'
    if operation == '1':
        data['operacion'] = data[col1] + data[col2]
        return (True,data)
    elif operation == '2':
        data['operacion'] = data[col1] - data[col2]
        return (True,data)
    elif operation == '3':
        data['operacion'] = (data[col1] + data[col2]) / 2
        return (True,data)
    else:
        print('Oops it seems that you dont enter a valid option')
        return (False,data)

if __name__ == '__main__':
    filesToRead = 2
    files = {}
    option = '.xlsx'
    files = {'0. El Pueblo.xlsx': ['COD PRODUCTO', 'DESCRIPCIÓN', 'UNIDADES'], 'CODIGOS_TQ.xlsx': ['COD PRODUCTO', 'COD TQ']}
    newData =  DataFrames(files, option)
    done, newData = operations(newData)
    if done:
        newData.to_excel('output1.xlsx')



    #while(True):
        
        #option = menu()
        #if option == False:
        #    break
        #files = readNamesAndColums(option, filesToRead)