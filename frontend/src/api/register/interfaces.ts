export interface IRegisterApi {
    register: (email: string, name: string, password: string) => Promise<Response>;
}