import { Veiculo } from "./veiculo";

export interface Marca {
    id: string,
    nome: string,
    status: number,
    veiculos: Veiculo[]
}