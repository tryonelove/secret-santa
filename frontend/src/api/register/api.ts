import { defaultFetchParams, HttpRequest } from '../constants';
import { REGISTER_URL } from './constants';

export const register = async (email: string, name: string, password: string) => {
    const body = {
        email: email,
        name: name,
        password: password
    };

    const request = await fetch(REGISTER_URL, {
        ...defaultFetchParams,
        method: HttpRequest.POST,
        body: JSON.stringify(body)
    });

    if (!request.ok) {
        throw Error(request.statusText);
    }

    const response = request.json();

    return response;
}