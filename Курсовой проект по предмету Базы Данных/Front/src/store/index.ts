// src/store/index.ts
import { configureStore } from '@reduxjs/toolkit';
import userReducer from './slices/userSlice';
import cartReducer from './slices/cartSlice'; // Импортируйте ваш слайс корзины

const store = configureStore({
  reducer: {
    user: userReducer,
    cart: cartReducer, // Добавьте редьюсер корзины
  },
});

export type RootState = ReturnType<typeof store.getState>;
export type AppDispatch = typeof store.dispatch;

export default store;
