import { useState } from 'react';

interface FormProps {
  title: string;
  handleClick: (email: string, password: string) => void;
}

const Form: React.FC<FormProps> = ({ title, handleClick }) => {
  const [email, setEmail] = useState<string>('');
  const [pass, setPass] = useState<string>('');

  return (
    
    <div className='center-form'>
      <div>
      <input
        className="input-container"
        type="email"
        value={email}
        onChange={(e) => setEmail(e.target.value)}
        placeholder="email"
      />
      </div>
      <div>
      <input
        className="input-container"
        type="password"
        value={pass}
        onChange={(e) => setPass(e.target.value)}
        placeholder="password"
      />
      </div>
      <div>
      <button
        className='input-container'
        onClick={() => handleClick(email, pass)}
      >
        {title}
      </button>
      </div>
      
      
      
    </div>
  );
};

export { Form };
