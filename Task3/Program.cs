using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Program
    {
//  Задание 3
//          Создайте абстрактный класс Гражданин.Создайте классы Студент, Пенсионер, Рабочий
//          унаследованные от Гражданина. Создайте непараметризированную коллекцию со следующим
//          функционалом:
//  1. Добавление элемента в коллекцию.
//  1) Можно добавлять только Гражданина.
//  2) При добавлении, элемент добавляется в конец коллекции.Если Пенсионер, – то в
//  начало с учетом ранее стоящих Пенсионеров. Возвращается номер в очереди.
//  3) При добавлении одного и того же человека(проверка на равенство по номеру
//  паспорта, необходимо переопределить метод Equals и/или операторы равенства для
//  сравнения объектов по номеру паспорта) элемент не добавляется, выдается
//  сообщение.
//  2. Удаление
//  1) Удаление – с начала коллекции.
//  2) Возможно удаление с передачей экземпляра Гражданина.
//  3. Метод Contains возвращает true/false при налчичии/отсутствии элемента в коллекции и
//  номер в очереди.
//  4. Метод ReturnLast возвращsает последнего человека в очереди и его номер в очереди.
//  5. Метод Clear очищает коллекцию.
//  6. С коллекцией можно работать опертаором foreach.

        static void Main(string[] args)
        {
            var queue = new MyCollection()
            {
                new Worker(new Passport("worker1", 1)),
                new Pensioner(new Passport("pensioner1", 2)),
                new Student(new Passport("student1", 2)),
                new Student(new Passport("student2", 2))
            };

            queue.Add(new Pensioner(new Passport("pensioner1", 2)));
            queue.Add(new Pensioner(new Passport("pensioner2", 2)));
            queue.Remove();
            queue.Remove(new Worker(new Passport("worker1", 1)));

            Console.WriteLine(queue);

            Console.ReadKey();
        }
    }
}
