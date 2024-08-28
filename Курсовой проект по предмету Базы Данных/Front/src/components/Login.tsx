import { useDispatch } from 'react-redux';
import { useNavigate } from 'react-router-dom';
import { getAuth, signInWithEmailAndPassword } from 'firebase/auth';
import { Form } from './Form';
import { setUser } from '../store/slices/userSlice';
import app from '../firebase';


const Login: React.FC = () => {
  const dispatch = useDispatch();
  const navigate = useNavigate();

  const handleLogin = (email: string, password: string) => {
    const auth = getAuth(app);
    signInWithEmailAndPassword(auth, email, password)
      .then(async ({ user }) => {
        const token = await user.getIdToken();
        dispatch(setUser({
          email: user.email ?? '',  // Use empty string as fallback
          id: user.uid,
          token,
        }));
        navigate('/homepage');
      })
      .catch(() => alert('Invalid user!'));
  };

  return (
    <Form
      title="Войти"
      handleClick={handleLogin}
    />
  );
};

export { Login };
