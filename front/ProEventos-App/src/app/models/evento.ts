import { Lote } from "./lote";
import { Palestrante } from "./palestrante";
import { RedeSocial } from "./redeSocial";

/**
 * Interface que representa o modelo de dados de um evento.
 */
export interface Evento {
    id: number;
    local: string;
    dataEvento: Date;
    tema: string;
    quantidadePessoas: number;
    imagemURL: string;
    telefone: string;
    email: string;
    lotes: Lote[];
    redesSociais: RedeSocial[];
    palestranteEventos: Palestrante[];
}
