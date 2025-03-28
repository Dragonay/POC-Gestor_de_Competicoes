import { Component, OnInit } from '@angular/core';
import { Categoria } from '../interfaces/Categoria';
import { Competidor } from '../interfaces/Competidor';
import { CategoriaService } from '../services/categoria.service';
import { CompetidorService } from '../services/competidor.service';
import { ActivatedRoute, Router } from '@angular/router';
import { UserService } from '../services/user.service';
import { InscricaoService } from '../services/inscricao.service';
import { Inscricao } from '../interfaces/Inscricao';
import { CompeticaoService } from '../services/competicao.service';

@Component({
  selector: 'app-inscricao-competicao',
  templateUrl: './inscricao-competicao.component.html',
  styleUrls: ['./inscricao-competicao.component.css']
})
export class InscricaoCompeticaoComponent implements OnInit {
  categorias: Categoria[] = [];
  competidores: Competidor[] = [];
  valorTotal = 0;
  isModalOpen = false;
  isQrCodeGenerated = false;
  qrCodeUrl = '';
  categoriaSelecionada: any = {};
  competidor = { nome: '' };
  isFinalizarModalOpen = false;
  competicaoId: number = 0;
  infoModals: {
    quantidadeInscricoes: number, competidoresSelecionados: any[], categoriaId: number,
    competidoresDesabilitados: any[]
  }[] = [];
  indexCategoria: number = 0;
  showSuccessMessage: boolean = false;
  idOrganizador: number = 0;
  emailOrganizador: string= ""
  inscricoes: Inscricao[] = []

  constructor(private categoriaService: CategoriaService,
    private competidorService: CompetidorService,
    private userService: UserService,
    private route: ActivatedRoute,
    private inscricaoService: InscricaoService,
    private competicaoService: CompeticaoService,
    private router: Router
  ) { }

  ngOnInit() {
    this.competicaoId = Number(this.route.snapshot.paramMap.get('id'));
    this.pegarEmailOrganizador();
    this.loadCategorias();
    this.loadCompetidores();
  }

  pegarEmailOrganizador()
  {
    this.competicaoService.getCompeticao(this.competicaoId).subscribe(competicao => {
      this.userService.getUser(competicao.criadorUsuarioId).subscribe(organizador => {
        this.idOrganizador = organizador.id;
        this.emailOrganizador = organizador.email
      });
    });
  }

  loadCategorias() {
    this.categoriaService.getCategoriasPorCompeticao(this.competicaoId).subscribe(categorias => {
      this.categorias = categorias;
      this.infoModals = categorias.map((categoria) => ({
        quantidadeInscricoes: 0, competidoresSelecionados: [],
        categoriaId: categoria.id, competidoresDesabilitados: []
      }));
    });
  }

  loadCompetidores() {
    this.userService.getUsuarioLogado().subscribe(usuario => {
      this.competidorService.buscarCompetidoresDoUsuario(usuario.id).subscribe(competidores => {
        this.competidores = competidores;
        this.infoModals.forEach(infoModal => {
          this.filtrarCompetidores(infoModal);
        });
      });
    });
  }

  openInscricaoModal(categoria: any, index: number) {
    this.categoriaSelecionada = categoria;
    this.indexCategoria = index;
    this.isModalOpen = true;
  }

  filtrarCompetidores(infoModal: any) {
    const categoriaId = infoModal.categoriaId;
    this.inscricaoService.getInscricoesPorCategoria(categoriaId).subscribe(inscricoes => {
      inscricoes.forEach(inscricao => {
        this.competidores.forEach(competidor => {
          if (inscricao.competidorId === competidor.id) {
            infoModal.competidoresDesabilitados.push(competidor);
          }
        }
        )
      }
      )
    })
  }

  closeInscricaoModal() {
    this.isModalOpen = false;
  }

  inscreverCompetidor() {
    if (this.infoModals[this.indexCategoria].competidoresSelecionados.length < this.infoModals[this.indexCategoria].quantidadeInscricoes) {
      alert('Você precisa selecionar todos os competidores da categoria.');
      return;
    }
    for (let i = 0; i < this.infoModals[this.indexCategoria].competidoresSelecionados.length; i++) {
      if (this.infoModals[this.indexCategoria].competidoresSelecionados[i] === undefined) {
        alert('Você precisa selecionar todos os competidores da categoria.');
        return;
      }
    }

    this.valorTotal = 0;
    for (let i = 0; i < this.infoModals.length; i++) {
      this.valorTotal += this.categorias[i].valorInscricao * this.infoModals[i].quantidadeInscricoes;
    }
    this.closeInscricaoModal();
  }

  finalizarInscricoes() {
    this.isFinalizarModalOpen = true;
  }

  closeFinalizarModal() {
    this.isFinalizarModalOpen = false;
  }

  onSubmit() {
    this.infoModals.forEach((info) => {
      info.competidoresSelecionados.forEach((competidor) => {
        let novaInscricao: Inscricao = {
          id: 0,
          categoriaId: info.categoriaId,
          status: 0,
          competidorId: competidor.id,
          pagamentoId: null,
          posicao: 0,
          wo: false,
          premioResgatavelId: null
        }
        console.log(novaInscricao)
        this.inscricaoService.cadastrarInscricao(novaInscricao).subscribe(inscricao => {
          novaInscricao.id = inscricao.id
          this.inscricoes.push(novaInscricao);
        },
          error => alert(error.error));
      })
    })
    this.showSuccessMessage = true;
  }

  hideSuccessMessage() {
    this.showSuccessMessage = false;
    const inscricoesIds = this.inscricoes.map(inscricao => inscricao.id);
    console.log(JSON.stringify({ inscricoes: this.inscricoes, emailOrganizador: this.emailOrganizador }));

    this.inscricaoService.enviarInscricoesParaOrganizador(inscricoesIds, this.emailOrganizador, this.idOrganizador).subscribe(ok =>
    {
      console.log(ok)
      this.router.navigate(['/minhas-inscricoes']);
    }
    );
  }
}