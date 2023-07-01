using ATM_Challenge.DTO.Services;
using ATM_Challenge.DTO.Entities;

Console.WriteLine("Hello, World!");

var Cards = CardService.GetCards();

foreach (var Card in Cards)
{
    Console.WriteLine($"{Card.Number} {Card.DueDate} = {Card.IdCard}");
}

//Insertar un registro en la base de datos
var newCard = new Card()
{
    Number = "1111111111111111",
    Pin = "1234",
    DueDate = DateTime.Now,
    Attempts = 0,
    Lock = false
}; //var id = CardService.CreateCard(newCard); Console.WriteLine($"Se creo la nota con id = {id}");

//Buscar un registro por id
var findCard = CardService.GetCard(1); Console.WriteLine($"El registro con {1} tiene numero {findCard.Number}");

//Actualizar un registro en la base de datos
//findCard.Number = "Pedro"; CardService.UpdateCard(findCard, id) ;Console.WriteLine($"El registro con {id} ahora se llama Pedro {findCard.Number}");

//CardService.DeleteCard(id); Console.WriteLine($"Pedro ahora está en un lugar mejor...");