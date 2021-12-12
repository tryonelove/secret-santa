import { Link } from 'react-router-dom';
import { REGISTRATION_PATH } from '../Registration';
import { Logo } from './Logo';
import { Register } from './Register';

export const Header = () => {
  return (
    <div className='grid grid-cols-2 h-16 bg-white drop-shadow'>
      <Link to='/' className='max-w-8xl mx-auto self-center'>
        <Logo className='text-xl font-semibold' />
      </Link>
      <Link to={REGISTRATION_PATH} className='max-w-8xl mx-auto self-center'>
        <Register className='text-l font-medium text-orange-500' />
      </Link>
    </div>
  );
};
