import React from 'react';
import { Routes, Route } from 'react-router-dom';
import HomePage from './pages/HomePage';
import LoginPage from './pages/LoginPage';
import RegisterPage from './pages/RegisterPage';
import Basket from './pages/Basket';
import 'bootstrap/dist/css/bootstrap.min.css';
import About from './pages/About';


const App: React.FC = () => {
  return (
    <Routes>
      <Route path="/homepage" element={<HomePage />} />
      <Route path="/about" element={<About />} />
      <Route path="/" element={<LoginPage />} />
      <Route path="/register" element={<RegisterPage />} />
      <Route path="/basket" element={<Basket />} />
    </Routes>
  );
}

export default App;
