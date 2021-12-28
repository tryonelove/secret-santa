import * as Yup from 'yup';

const registrationValidationSchema = Yup.object().shape({
    name: Yup.string()
        .min(2, 'Слишком короткое имя.')
        .required('Имя обязательно.'),
    email: Yup.string().email('Неверный email.').required('email обязателен.'),
    password: Yup.string().required('Пароль обязателен.'),
});

export { registrationValidationSchema };