export interface Usuarios {
    Identificador: number,
    Usuarios: string,
    Password:string,
    FechaCreacion:string
}

export interface Personas {
    Identificador: number,
    Nombres: string,
    Apellidos:string,
    TipoIdentificacion:string,
    emaiil:string,
    NoIdentificacion:string,
    FechaCreacion:string,
    NombresyApellidos:string,
    TipoIdentificacionyNoIdentificacion:string
}

export interface AuthenticatedResponse{
    token: string;
}

export interface LoginModel {
    usuario: string;
    password: string;
}