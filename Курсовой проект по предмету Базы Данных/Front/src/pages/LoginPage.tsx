import { Login } from '../components/Login';
import { Link } from 'react-router-dom';

const LoginPage: React.FC = () => {
  return (
     
    <div className='center'>
      <h1 className='center'>Вход</h1>
      <Login />
      <p>
        <Link to="/register">Зарегистрируйтесь</Link>
      </p>
    </div>
  );
};

export default LoginPage;
