import { Endereco } from "./endereco";
import { Nome } from "./nome";

export class Proprietario {

    constructor(
        id?: string,
        nome?: Nome,
        email?: string,
        endereco?: Endereco,
        status?: number,
        documento?: number) {
            this.id = id;
            this.nome = nome;
            this.email = email;
            this.endereco = endereco;
            this.status = status;
            this.documento = documento;
    }

    public id?: string;
    public nome?: Nome;
    public email?: string;
    public endereco?: Endereco;
    public status?: number;
    public documento?: number
}