import React from 'react';
import { useNavigate } from 'react-router-dom';
import { useDispatch } from 'react-redux';
import { useAuth } from '../hooks/use-auth';
import { removeUser } from '../store/slices/userSlice';
import ProductList from '../components/ProductList';
import Header from '../components/Header'; // импортируем компонент BasicExample

const HomePage: React.FC = () => {
  const dispatch = useDispatch();
  const navigate = useNavigate(); // используем useNavigate для перехода на другие страницы

  const { isAuth, email } = useAuth();

  const handleGoToBasket = () => {
    navigate('/basket'); // перенаправляем пользователя на страницу корзины
  };

  const handleLogout = () => {
    dispatch(removeUser());
    navigate('/');
  };
  return isAuth ? (
    <div>
      <Header /> {/* Используем компонент шапки */}
      <h1>Добро пожаловать {email}!</h1>
      
      <div>
        <ProductList />
      </div>
    </div>
  ): (
    <button className="button-group" onClick={() => navigate('/')}>Войти</button>
  );
};

export default HomePage;
