using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebKursachAPI.Data;
using WebKursachAPI.Models;

[ApiController]
[Route("api/basket")]
public class BasketController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public BasketController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public IActionResult AddToBasket(Basket basketItem)
    {
        var existingItem = _context.Baskets.FirstOrDefault(b => b.EmailUser == basketItem.EmailUser && b.IdProduct == basketItem.IdProduct);

        if (existingItem != null)
        {
            // Если товар уже есть в корзине, увеличиваем его количество на 1
            existingItem.Quantity++;
            _context.SaveChanges();
            return Ok();
        }
        else
        {
            // Если товара нет в корзине, добавляем новый товар
            _context.Baskets.Add(basketItem);
            _context.SaveChanges();
            return Ok();
        }
    }


    [HttpGet("{email}")]
    public IActionResult GetBasketItems(string email)
    {
        var basketItems = _context.Baskets.Where(b => b.EmailUser == email).ToList();
        return Ok(basketItems);
    }


    // Метод для очистки корзины указанного пользователя
    [HttpDelete("clear/{email}")]
    public async Task<IActionResult> ClearBasket(string email)
    {
        try
        {
            // Находим все элементы корзины для указанного пользователя
            var basketItems = _context.Baskets.Where(item => item.EmailUser == email).ToList();

            // Удаляем найденные элементы корзины
            _context.Baskets.RemoveRange(basketItems);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Basket cleared successfully", clearedItems = basketItems });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { error = "Failed to clear basket", message = ex.Message });
        }
    }

}
