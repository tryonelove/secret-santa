import { HttpRequest } from '../constants';
import { REGISTER_URL } from './constants';

export const register = async (email: string, name: string, password: string) => {
    const body = {
        email: email,
        name: name,
        password: password
    };

    const response = await fetch(REGISTER_URL, {
        method: HttpRequest.POST,
        headers: {
            'Content-Type': 'application/json',
            'Access-Control-Allow-Origin': '*',
        },
        body: JSON.stringify(body)
    });

    return response.json();
}