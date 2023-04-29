import { Evento } from "./evento";
import { RedeSocial } from "./redeSocial";

/**
 * Interface que representa o modelo de dados de um palestrante.
 */
export interface Palestrante {
    id: number;
    nome: string;
    miniCurriculo: string;
    imagemURL: string;
    telefone: string;
    email: string;
    redesSociais: RedeSocial[];
    palestranteEventos: Evento[];
}
