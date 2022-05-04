import { Nome } from "./nome";
import { Veiculo } from "./veiculo";

export class Marca {

    constructor(
        id?: string,
    nome?: Nome,
    status?: number,
    ) {
        this.id = id
        this.nome = nome,
        this.status = status
        this. veiculos = []
    }

    public id?: string;
    public nome?: Nome;
    public status?: number;
    public veiculos?: Veiculo[]
}