import { SignUp } from '../components/SignUp';
import { Link } from 'react-router-dom';

const RegisterPage: React.FC = () => {
  return (
    <div>
      <h1>Регистрация</h1>
      <SignUp />
      <p>
        У вас уже есть аккаунт? <Link to="/login">Войдите!</Link>
      </p>
    </div>
  );
};

export default RegisterPage;
