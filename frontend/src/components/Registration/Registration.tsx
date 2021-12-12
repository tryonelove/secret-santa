import { Field, Form, Formik } from 'formik';
import { useNavigate } from 'react-router-dom';
import * as Yup from 'yup';
import { register } from '../../api/register/api';

const registrationValidationSchema = Yup.object().shape({
  name: Yup.string()
    .min(2, 'Слишком короткое имя.')
    .required('Имя обязательно.'),
  email: Yup.string().email('Неверный email.').required('email обязателен.'),
  password: Yup.string().required('Пароль обязателен.'),
});

export function Registration() {
  const navigate = useNavigate();

  return (
    <Formik
      initialValues={{
        name: '',
        email: '',
        password: '',
      }}
      onSubmit={({ email, name, password }) => {
        register(email, name, password).then(() => {
          navigate('/');
        });
      }}
      validationSchema={registrationValidationSchema}
    >
      {({ errors, touched }) => (
        <Form>
          <div className='grid grid-rows-4 md:w-1/4 w-4/6 mx-auto'>
            <div className='mt-4'>
              <label htmlFor='email'>Ваша почта</label>
              <Field
                id='email'
                name='email'
                type='text'
                className='mt-2 block w-full rounded-md border-gray-300 shadow-sm focus:border-indigo-300 focus:ring focus:ring-indigo-200 focus:ring-opacity-50'
              />
              {errors.email && touched.email ? (
                <p className='mt-1 text-red-500 text-xs italic'>
                  {errors.email}
                </p>
              ) : null}
            </div>
            <div className='mt-4'>
              <label htmlFor='email'>Ваше имя</label>
              <Field
                id='name'
                name='name'
                type='text'
                className='mt-2 block w-full rounded-md border-gray-300 shadow-sm focus:border-indigo-300 focus:ring focus:ring-indigo-200 focus:ring-opacity-50'
              />
              {errors.name && touched.name ? (
                <p className='mt-1 text-red-500 text-xs italic'>
                  {errors.name}
                </p>
              ) : null}
            </div>
            <div className='mt-4'>
              <label htmlFor='email'>Ваш пароль</label>
              <Field
                id='password'
                name='password'
                type='password'
                className='mt-2 block w-full rounded-md border-gray-300 shadow-sm focus:border-indigo-300 focus:ring focus:ring-indigo-200 focus:ring-opacity-50'
              />
              {errors.password && touched.password ? (
                <p className='mt-1 text-red-500 text-xs italic'>
                  {errors.password}
                </p>
              ) : null}
            </div>
            <button
              className='mt-8 bg-red-500 hover:bg-red-600 hover:shadow-md text-white font-bold py-2 px-4 rounded-full'
              type='submit'
            >
              Зарегистрироваться
            </button>
          </div>
        </Form>
      )}
    </Formik>
  );
}
