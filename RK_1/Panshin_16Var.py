

class Book:
    def __init__(self, id, name, price, store_id):
        self.id = id
        self.name = name
        self.price = price
        self.store_id = store_id


class BookStore:
    def __init__(self, id, name):
        self.id = id
        self.name = name

class Book_BookStore:
    def __init__(self, book_id, store_id):
        self.book_id = book_id
        self.store_id = store_id



def get_one_to_many(books, stores):   #Проходим по книгам и книжным магазинам, проверяя store_id в книге и id магазина 
    return [
        (b.name,b.price,s.name) 
                   for b in books 
                   for s in stores
                   if b.store_id == s.id]

def get_many_to_many(books, stores, book_bookstore): #Проходим по связующей таблице и находим книги, которые соответсвуют магазинам 
    return [
        (b.name, b.price, s.name)
                    for bs in book_bookstore        
                    for s in stores
                    for b in books 
                    if s.id ==  bs.store_id and b.id == bs.book_id
    ]

def task_1 (stores,one_to_many):
    res = {}
    for store in stores:
        if "Book" in store.name:
            book_store = []
            for book_name, price, store_name in one_to_many:
                if store_name == store.name:
                    book_store.append(book_name)
            res[store.name] = book_store
    return res


def task_2 (stores, one_to_many):
    res_not_sorted = []
    #Проходим через все магазины и список один ко многим. Проверяем совпадение магазина книги, после чего добавляем в несортированный словарь результата среднюю цену книг в магазине.
    #И в конце сортируем словарь результата по значениям
    for store in stores:
        book_store = []
        for book_name,price,store_name in one_to_many:
            if  store_name == store.name:
                book_store.append((book_name,price))
        if(len(book_store) > 0):
            res_not_sorted.append((store.name,
                sum([round(price/len(book_store),2) for _,price in book_store  ]))
                )
    res = dict(sorted(res_not_sorted, key = lambda item : item[1], reverse = True))
    
    return res

def task_3 (books, many_to_many):
    res = {}
    #Находим книги, которые начинаются на 'П' и через список многие ко многим находим все магазины, в которых находятся  эти книги, и добавляем в словарь результата, где ключ - Название книги, а значение - список магазинов
    for book in books:
        if book.name[0] == 'П':
            book_store = []
            for book_name,_,store_name in many_to_many:
                if (book_name == book.name):
                    book_store.append(store_name)
            res[book.name] = book_store

    return res





def main():
    
    books = [
        Book(1,"Темная башня",1799,1),
        Book(2,"Молот вулкана",400,3),
        Book(3,"Повелитель мух",499,4),
        Book(4,"1984",999,2),
        Book(5,"Противостояние",2100,5),
        Book(6,"Гарри Поттер и узник азкабана", 1701.23,3),
    
    ]

    book_bookstore = [
        Book_BookStore(1,1),
        Book_BookStore(2,3),
        Book_BookStore(3,4),
        Book_BookStore(4,2),
        Book_BookStore(5,5),

        Book_BookStore(2,2),
        Book_BookStore(5,2),
        Book_BookStore(3,5)
    ]   

    stores = [
        BookStore(1,"Pioner Bookstore"),
        BookStore(2,"Garage Bookshop"),    
        BookStore(3,"Bookbridge"),
        BookStore(4,"Ходасевич"),
        BookStore(5,"Гиперион")
    ]

    one_to_many = get_one_to_many(books, stores)
    many_to_many = get_many_to_many(books,stores,book_bookstore)


    print("Задание E1\n«Книжный магазин» и «Книга» связаны соотношением один-ко-многим.Выведите список всех магазинов, в названии которых есть слово «Book», и названия книг в этих магазинах",
          task_1(stores, one_to_many))
  
  
    print("\nЗадание E2\n«Книжный магазин» и «Книга» связаны соотношением один-ко-многим.Выведите список магазинов со средней ценой книг в каждом магазине, отсортированный по средней цене.",
          task_2(stores,one_to_many))

    print("\nЗадание E3")
    print("«Книжный магазин» и Книга» связаны соотношением многие-ко-многим. Выведите список всех книг, у которых название начинается с буквы «П», и список магазинов, содержащих эти книги.",
          task_3(books,many_to_many))

   
   
if __name__ == '__main__':
    main()