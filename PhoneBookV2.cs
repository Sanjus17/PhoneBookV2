using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace phonebook
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Dictionary<int, string[]> book = new Dictionary<int, string[]>();
            Console.WriteLine("Вы открыли телефонную книжку!");
            string action;
            int id = 0;
            do
            {
                Console.WriteLine("Выберите действие:\n1 - Создать запись\n2 - Редактировать запись\n3 - Удалить запись\n4 - просмотреть запись\n5 - просмотреть  краткую информацию всех записей\n6 - закрыть телефонную книжку");
                Console.WriteLine();
                action = Console.ReadLine();
                if (action == "1") { id = MakeChangeDeleteNotes.MakeNotes(book, id); }
                else if (action == "2") { MakeChangeDeleteNotes.ChangeNotes(book); }
                else if (action == "3") { MakeChangeDeleteNotes.DeleteNotes(book); }
                else if (action == "4") { WatchNotes.WatchNote(book); }
                else if (action == "5") { WatchNotes.WatchAllNotes(book); }
                else if (action == "6") { Console.WriteLine(); Console.WriteLine("Вы закрыли телефонную книжку!"); }
                else { Console.WriteLine(); Console.WriteLine("Такого действия нет. Попробуйте снова!"); Console.WriteLine(); }

            } while (action != "6");
        }
    }
    public class MakeChangeDeleteNotes
    {
        public static string[] MakeNote()
        {
            string[] note = new string[9];

            Console.Write("Фамилия: ");
            note[0] = Console.ReadLine();
            Console.Write("Имя: ");
            note[1] = Console.ReadLine();
            Console.Write("Отчество (нажмите Enter, чтобы пропустить): ");
            note[2] = Console.ReadLine();
            bool convert;
            do
            {
                Console.Write("Номер телефона: ");
                string phone_number = Console.ReadLine();
                convert = long.TryParse(phone_number, out long phonenumber);
                if (convert) { note[3] = phone_number; }
                else { Console.WriteLine(); Console.WriteLine("Номер телефона должен состоять только из цифр!"); Console.WriteLine(); }
            } while (convert != true);
            Console.Write("Страна: ");
            note[4] = Console.ReadLine();
            Console.Write("Дата рождения (нажмите Enter, чтобы пропустить): ");
            note[5] = Console.ReadLine();
            Console.Write("Организация (нажмите Enter, чтобы пропустить): ");
            note[6] = Console.ReadLine();
            Console.Write("Должность (нажмите Enter, чтобы пропустить): ");
            note[7] = Console.ReadLine();
            Console.Write("Прочие заметки (нажмите Enter, чтобы пропустить): ");
            note[8] = Console.ReadLine();

            return note;
        }
        public static int MakeNotes(Dictionary<int, string[]> book, int id)
        {
            id++;
            book.Add(id, MakeChangeDeleteNotes.MakeNote());
            Console.WriteLine();
            Console.WriteLine($"Запись №{id} добавлена!");
            Console.WriteLine();
            return id;
        }
        public static void ChangeNotes(Dictionary<int, string[]> book)
        {
            Console.Write("Введите номер записи, которую вы хотите изменить: ");
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine();
            if (book.ContainsKey(number))
            {
                Console.Write("Выберите пункт, который вы хотите изменить:\n1 - Фамилия\n2 - Имя\n3 - Отчество\n4 - Номер телефона\n5 - Страна\n6 - Дата рождения\n7 - Организация\n8 - Должность\n9 - Прочие заметки");
                Console.WriteLine();
                Console.WriteLine();
                int point = int.Parse(Console.ReadLine());
                if (point == 1)
                {
                    Console.Write("Введите фамилию: ");
                    book[number][0] = Console.ReadLine();
                    Console.WriteLine();
                    Console.WriteLine($"Запись №{number} изменена!");
                }
                else if (point == 2)
                {
                    Console.Write("Введите имя: ");
                    book[number][1] = Console.ReadLine();
                    Console.WriteLine();
                    Console.WriteLine($"Запись №{number} изменена!");
                }
                else if (point == 3)
                {
                    Console.Write("Введите отчество: ");
                    book[number][2] = Console.ReadLine();
                    Console.WriteLine();
                    Console.WriteLine($"Запись №{number} изменена!");
                }
                else if (point == 4)
                {
                    Console.Write("Введите номер телефона: ");
                    string phone_number = Console.ReadLine();
                    bool convert = long.TryParse(phone_number, out long phonenumber);
                    if (convert)
                    {
                        book[number][3] = phone_number; Console.WriteLine(); Console.WriteLine($"Запись №{number} изменена!");
                    }
                    else { Console.WriteLine(); Console.WriteLine("Номер телефона должен состоять только из цифр!"); }
                }
                else if (point == 5)
                {
                    Console.Write("Введите страну: ");
                    book[number][4] = Console.ReadLine();
                    Console.WriteLine();
                    Console.WriteLine($"Запись №{number} изменена!");
                }
                else if (point == 6)
                {
                    Console.Write("Введите дату рождения: ");
                    book[number][5] = Console.ReadLine();
                    Console.WriteLine();
                    Console.WriteLine($"Запись №{number} изменена!");
                }
                else if (point == 7)
                {
                    Console.Write("Введите организацию: ");
                    book[number][6] = Console.ReadLine();
                    Console.WriteLine();
                    Console.WriteLine($"Запись №{number} изменена!");
                }
                else if (point == 8)
                {
                    Console.Write("Введите должность: ");
                    book[number][7] = Console.ReadLine();
                    Console.WriteLine();
                    Console.WriteLine($"Запись №{number} изменена!");
                }
                else if (point == 9)
                {
                    Console.Write("Введите прочие заметки: ");
                    book[number][8] = Console.ReadLine();
                    Console.WriteLine();
                    Console.WriteLine($"Запись №{number} изменена!");
                }
                else { Console.WriteLine("Такого пункта нет!"); }
            }
            else { Console.WriteLine("Записи с таким номером нет в телефонной книжке!"); }
            Console.WriteLine();
        }
        public static void DeleteNotes(Dictionary<int, string[]> book)
        {
            Console.Write("Введите номер записи, которую вы хотите удалить: ");
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine();
            if (book.ContainsKey(number)) { book.Remove(number); Console.WriteLine($"Запись №{number} удалена!"); }
            else { Console.WriteLine("Записи с таким номером нет в телефонной книжке!"); }
            Console.WriteLine();
        }

    }
    public class WatchNotes
    {
        public static void WatchNote(Dictionary<int, string[]> book)
        {
            Console.Write("Введите номер записи, которую вы хотите просмотреть: ");
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine();
            if (book.ContainsKey(number))
            {
                Console.WriteLine($"Фамилия: {book[number][0]}\nИмя: {book[number][1]}");
                if (book[number][2] != "") { Console.WriteLine($"Отчество: {book[number][2]}"); }
                Console.WriteLine($"Номер телефона: {book[number][3]}\nСтрана: {book[number][4]}");
                if (book[number][5] != "") { Console.WriteLine($"Дата рождения: {book[number][5]}"); }
                if (book[number][6] != "") { Console.WriteLine($"Организация: {book[number][6]}"); }
                if (book[number][7] != "") { Console.WriteLine($"Должность: {book[number][7]}"); }
                if (book[number][8] != "") { Console.WriteLine($"Прочие заметки: {book[number][8]}"); }
            }
            else { Console.WriteLine("Записи с таким номером нет в телефонной книжке!"); }
            Console.WriteLine();
        }
        public static void WatchAllNotes(Dictionary<int, string[]> book)
        {
            Console.WriteLine();
            foreach (var item in book)
            {
                Console.WriteLine($"Запись №{item.Key}\nФамилия: {item.Value[0]}\nИмя: {item.Value[1]}\nНомер телефона: {item.Value[3]}");
                Console.WriteLine();
            }
        }
    }
}
