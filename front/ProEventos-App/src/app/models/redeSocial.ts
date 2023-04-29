import { Evento } from "./evento";
import { Palestrante } from "./palestrante";

/**
 * Interface que representa o modelo de dados de uma rede social.
 */
export interface RedeSocial {
    id: number;
    nome: string;
    url: string;
    eventoId?: number;
    evento: Evento;
    palestranteId?: number;
    palestrante: Palestrante;
}
