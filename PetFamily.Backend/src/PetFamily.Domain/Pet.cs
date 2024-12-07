namespace PetFamily.Domain
{
    public class Pet
    {
        /*Нужно создать доменную богатую модель домашнего животного - Pet со следующими полями:

1. Id   
2. Кличка
3. Вид(например - собака, кошка)
4. Общее описание
5. Порода
6. Окрас
7. Информация о здоровье питомца
8. Адрес, где находится питомец
9. Вес
10. Рост
11. Номер телефона для связи с владельцем
12. Кастрирован или нет
13. Дата рождения
14. Вакцинирован или нет
15. Статус помощи - Нуждается в помощи/Ищет дом/Нашел дом
16. Реквизиты для помощи(у каждого реквизита будет название и описание, как сделать перевод), поэтому нужно сделать отдельный класс для реквизита.
17. Дата создания*/

        public Guid Id { get; set; }
        public string ByName { get; set; } = null!;
        public string AnimalType { get; set; } = null!; //enum?
        public string Description { get; set;} = null!;
        public string Breed { get; set;} = null!;
        public string Color { get; set;} = null!;
        public string PetHealthInfo { get; set;} = null!;
        public IAddress Address { get; set;} = null!; //VO
      
    }

    public class PetAddress:IAddress
    {
    }

    public interface IAddress
    {
    }


}
