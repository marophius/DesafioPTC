export class Endereco {
    /**
     *
     */
    constructor(
        cep?: string,
        state?: string,
        city?: string,
        street?: string,
        service?: string,
        neighborhood?: string
    ) {
        this.cep = cep;
        this.state = state;
        this.city = city;
        this.street = street;
        this.service = service;
        this.neighborhood = neighborhood;
    }

    public cep?: string;
    public state?: string;
    public city?: string;
    public street?: string;
    public service?: string;
    public neighborhood?: string;
}