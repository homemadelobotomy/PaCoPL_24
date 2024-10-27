

class File:
    def __init__(self, id, name, size, cat_id):
        self.id = id
        self.name = name
        self.size = size
        self.cat_id = cat_id


class Catalog:
    def __init__(self, id, name):
        self.id = id
        self.name = name

class FileCatolog:
    def __init__(self, file_id, cat_id):
        self.file_id = file_id
        self.cat_id = cat_id




files = [
    File(1,"sound.mp3",2300,1),
    File(2,"photo.jpg",4275,3),
    File(3,"inception.mp4",7523495,4),
    File(4,"lab_2.pdf",934,2),
    File(5,"book.pdf",17432,5),
    File(6,"setup.exe",28786,5),
    
]

file_catalog = [
    FileCatolog(1,1),
    FileCatolog(2,3),
    FileCatolog(3,4),
    FileCatolog(4,2),
    FileCatolog(5,5),

    FileCatolog(2,2),
    FileCatolog(5,2),
    FileCatolog(3,5)
]

catalogs = [
    Catalog(1,"Музыка"),
    Catalog(2,"Документы"),    
    Catalog(3,"Изображения"),
    Catalog(4,"Видео"),
    Catalog(5,"Загрузки")
]
def main():
    #Проходим по файлам и каталогам, проверяя cat_id в файле и id каталога 
    one_to_many = [
        (f.name,f.size,c.name) 
                   for f in files 
                   for c in catalogs
                   if f.cat_id == c.id]
    
    #Проходим по связующей таблице и находим файлы, которые соответсвуют категориям 
    many_to_many = [
        (f.name, f.size, c.name)
                    for fc in file_catalog        
                    for c in catalogs
                    for f in files 
                    if c.id == fc.cat_id and f.id == fc.file_id
    ]
    
    print("Задание Д1\n«Каталог» и «Файл» связаны соотношением один-ко-многим.Выведите список всех файлов, у которых расширение «pdf», и названия их каталогов")
    #В генераторе проходим по списку один ко многим и добавляем в словарь все файлы, у которых значение после точки равно pdf, и каталоги этих файлов
    res_1 = [(name,cat_name)
             for name,_,cat_name in one_to_many
             if name[name.find('.') + 1 : ] == "pdf"]
    print(res_1)
  
  
    print("\nЗадание Д2\n«Каталог» и «Файл» связаны соотношением один-ко-многим.Выведите список каталогов со средним весом файлов в каждом каталоге, отсортированный по среднему весу.")

    res_2_not_sorted = []
    #Проходим через все каталоги и список один ко многим. Проверяем совпадение каталога файла, после чего добавляем в несортированный словарь результата средний вес файлов в каталоге.
    #И в конце сортируем словарь результата по значениям
    for cat in catalogs:
        cat_files = []
        for file_name,size,cat_name in one_to_many:
            if  cat_name == cat.name:
                cat_files.append((file_name,size))
        if(len(cat_files) > 0):
            res_2_not_sorted.append((cat.name,
                sum([size/len(cat_files) for _,size in cat_files  ]))
                )
    res_2 = dict(sorted(res_2_not_sorted, key = lambda item : item[1], reverse = True))
    
    print(res_2)


    print("\nЗадание Д3\n")
    print("«Каталог» и «Файл» связаны соотношением многие-ко-многим. Выведите список всех каталогов, у которых название начинается с буквы «Д», и список файлов, находящихся в них.")

    res_3 = {}
    #Находим каталоги, которые начинаются на 'Д' и через список многие ко многим находим все файлы которые находятся в этом катологе и добавляем в словарь результата, где ключ - Название каталога, а значение - список файлов
    for cat in catalogs:
        if cat.name[0] == 'Д':
            cat_files = []
            for file_name,_,cat_name in many_to_many:
                if (cat_name == cat.name):
                    cat_files.append(file_name)
            res_3[cat.name] = cat_files

    print(res_3)
   
if __name__ == '__main__':
    main()