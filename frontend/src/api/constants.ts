export const BASE_URL = "https://localhost:7071/api"

export enum HttpRequest {
    GET = 'GET',
    POST = 'POST',
    PUT = 'PUT',
    DELETE = 'DELETE'
}

export enum Mode {
    CORS = 'cors'
}

export const defaultFetchParams = {
    mode: Mode.CORS,
    headers: {
        'Content-Type': 'application/json',
    },
}