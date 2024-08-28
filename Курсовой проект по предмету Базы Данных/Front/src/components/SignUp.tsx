import { useDispatch } from 'react-redux';
import { useNavigate } from 'react-router-dom';
import { getAuth, createUserWithEmailAndPassword } from 'firebase/auth';
import { Form } from './Form';
import { setUser } from '../store/slices/userSlice';
import app from '../firebase';

const SignUp: React.FC = () => {
  const dispatch = useDispatch();
  const navigate = useNavigate();

  const handleRegister = (email: string, password: string) => {
    const auth = getAuth(app);
    createUserWithEmailAndPassword(auth, email, password)
      .then(async ({ user }) => {
        const token = await user.getIdToken();
        dispatch(setUser({
          email: user.email ?? '',  // Use empty string as fallback
          id: user.uid,
          token,
        }));
        navigate('/homepage');
      })
      .catch(console.error);
  };

  return (
    <Form
      title="Зарегистрироваться"
      handleClick={handleRegister}
    />
  );
};

export { SignUp };
