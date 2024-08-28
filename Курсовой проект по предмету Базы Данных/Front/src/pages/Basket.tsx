import React, { useEffect, useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { useAuth } from '../hooks/use-auth';
import axios from 'axios';
import Header from '../components/Header';



interface BasketItem {
  id: number;
  emailUser: string;
  idProduct: number;
  quantity: number;
}

interface Product {
  id: number;
  name: string;
  description: string;
  price: number;
  imageUrl: string;
}

const BasketPage = () => {
  const navigate = useNavigate();
  const { isAuth, email } = useAuth();
  const [basketItems, setBasketItems] = useState<BasketItem[]>([]);
  const [renderedItems, setRenderedItems] = useState<JSX.Element[] | null>(null);
  const [totalPrice, setTotalPrice] = useState<number>(0);
  const [purchaseMessage, setPurchaseMessage] = useState<string>('');

  useEffect(() => {
    const fetchBasketItems = async () => {
      try {
        const response = await axios.get<BasketItem[]>(`https://localhost:7085/api/basket/${email}`);
        const items = response.data;
        setBasketItems(items);
      } catch (error) {
        console.error('Error fetching basket items:', error);
      }
    };

    fetchBasketItems();
  }, [email]);

  const fetchProductDetails = async (idProduct: number): Promise<Product | null> => {
    try {
      const response = await axios.get<Product>(`https://localhost:7085/api/product/${idProduct}`);
      return response.data;
    } catch (error) {
      console.error('Error fetching product details:', error);
      return null;
    }
  };

  const renderBasketItems = async () => {
    let total = 0;
    const items = await Promise.all(
      basketItems.map(async (item) => {
        const productDetails = await fetchProductDetails(item.idProduct);
        if (productDetails) {
          total += productDetails.price * item.quantity;
          return { ...item, ...productDetails } as BasketItem & Product;
        }
        return null;
      })
    );

    const renderedItems = items
  .filter((item): item is BasketItem & Product => item !== null)
  .map((item) => (
    <div key={item.id} className="product-card">
      <div className="card-body d-flex flex-column justify-content-between">
        <img
          src={item.imageUrl}
          alt={item.name}
          className="card-img-top mb-3"
          style={{ maxHeight: "200px", maxWidth: "200px" }}
        />
        <div>
          <h5 className="card-title">{item.name}</h5>
          <p className="card-text">{item.description}</p>
          <p className="card-text">Цена: {item.price} Рублей</p>
          <p className="card-text">Количество: {item.quantity}</p>
        </div>
      </div>
    </div>
  ));




    setTotalPrice(total);
    setRenderedItems(renderedItems);
  };

  useEffect(() => {
    renderBasketItems();
  }, [basketItems]);

  const handleBuyAll = async () => {
    try {
      await axios.delete(`https://localhost:7085/api/basket/clear/${email}`);
      setBasketItems([]); // Clear basket items in the client state
      setPurchaseMessage('Всё куплено, спасибо за покупку!'); // Set purchase message
    } catch (error) {
      console.error('Error clearing basket:', error);
    }
  };

  return isAuth ? (
    
    <div>
      <Header/>
      <h1>Корзина {email}</h1>
      {basketItems.length === 0 ? (
        <p>Ваша корзина пуста</p>
      ) : (
        <div className="product-list">{renderedItems}</div>
      )}
      <p></p>
      <p>Общая стоимость: {totalPrice.toFixed(2)} Рублей</p>
      
      <div className="button-group">
      <button onClick={handleBuyAll} className="btn btn-success">Купить всё</button>
      </div>
      
      
      {purchaseMessage && <p>{purchaseMessage}</p>} {/* Render purchase message */}
    </div>
  ): (
    <button className="button-group" onClick={() => navigate('/')}>Войти</button>
  );
};

export default BasketPage;
