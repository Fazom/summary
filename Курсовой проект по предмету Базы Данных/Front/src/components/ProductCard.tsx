import React from 'react';
import Card from 'react-bootstrap/Card';
import Button from 'react-bootstrap/Button';
import { useDispatch } from 'react-redux';
import { useSelector } from 'react-redux';
import { RootState } from '../store';
import { addToCart } from '../store/slices/cartSlice'; // Импортируйте действие для добавления в корзину
import axios from 'axios';

interface ProductCardProps {
  id: number;
  name: string;
  description: string;
  price: number;
  imageUrl: string;
}

const ProductCard: React.FC<ProductCardProps> = ({ id, name, description, price, imageUrl }) => {
  const dispatch = useDispatch();
  const { email: userStateEmail } = useSelector((state: RootState) => state.user);

  const handleAddToCart = async () => {
    try {
      const response = await axios.post('https://localhost:7085/api/basket', {
        id: 0,
        emailUser: userStateEmail,
        idProduct: id,
        quantity: 1
      });
      
      if (!response.data) {
        throw new Error('Failed to add item to cart');
      }

      // Обновление состояния корзины, если необходимо
    } catch (error) {
      console.error('Error adding item to cart:', error);
      // Обработка ошибки, например, отображение сообщения пользователю
    }
  };

  return (
    <Card style={{ width: '18rem', height: '30rem', background: '#f8f9fa', border: '1px solid #dee2e6', borderRadius: '10px' }}>
      <Card.Img
        variant="top"
        src={imageUrl}
        alt={name}
        style={{ maxHeight: '200px', maxWidth: '100%', objectFit: 'contain' }}
      />
      <Card.Body>
        <Card.Title style={{ fontWeight: 'bold', fontSize: '1.2em' }}>{name}</Card.Title>
        <Card.Text>{description}</Card.Text>
        <Card.Text>Цена: {price} руб</Card.Text>
        <Button variant="primary" onClick={handleAddToCart}>Добавить в корзину</Button>
      </Card.Body>
    </Card>
  );
};

export default ProductCard;
