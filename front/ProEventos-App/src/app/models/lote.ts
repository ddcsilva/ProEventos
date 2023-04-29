import { Evento } from "./evento";

/**
 * Interface que representa o modelo de dados de um lote.
 */
export interface Lote {
    id: number;
    nome: string;
    preco: number;
    dataInicio?: Date;
    dataFim?: Date;
    quantidade: number;
    eventoId: number;
    evento: Evento;
}
