
import './App.css';
import LoginForm from './components/Login';
import AddNeed from './components/PersonneDeparetement/AjouterBesoin';
import AddComputer from './components/PersonneDeparetement/AjouterOrdinateur';
import AddPrinter from './components/PersonneDeparetement/AjouterImpremente';
import { BrowserRouter, Routes,Route } from "react-router-dom";
import NavBar from './components/NavBarre';
import ListePersonneDepartement from './components/ChefDepartement/ListePersonDep';
import ListeBesoinDepartement from './components/ChefDepartement/ListeBesoinDep';
import Envoyer from './components/ChefDepartement/Envoyer';
import ErrorEnvoyer from './components/ChefDepartement/ErroEnvoyer';
import ListAppelOffreView from './components/Fournisseur/ListerAppelOffer';
import AfficherBesoins from './components/Fournisseur/Afficherbesoin';
import CreateOffre from './components/Fournisseur/CreateOffer';
import CreateRessource from './components/Ressources/Createressource';
import RessourceBesoin from './components/ChefDepartement/ListeBeoinDetaill';
import OrdinateurDetails from './components/Responsable/BesoinOrd';
import ImprimanteDetails from './components/Responsable/BesoinImp';
import ListeAppelsOffres from './components/Responsable/ListeAppelOffer';
import ListeBesoinResponsable from './components/Responsable/ListeBesoin';
import RessourceBesoinDetail from './components/Responsable/ListeBesoinDetail';
import AfficherBesoinsF from './components/Fournisseur/Afficherbesoin';
import Res_Detail_Frn from './components/Fournisseur/Res_Deatil_Forn';


function App() {
  return (
    <div className="App">
   
   <BrowserRouter>
            <NavBar />
            <Routes>
                <Route path="/" element={<LoginForm />} />
                <Route path="/ajouter-besoin" element={<AddNeed />} />
                <Route path="/ajouter-imprimante" element={<AddPrinter />} />
                <Route path="/ajouter-ordinateur" element={<AddComputer />} />
                <Route path="/liste-person-dep" element={<ListePersonneDepartement />} />
                <Route path="/liste-Besoins" element={<ListeBesoinDepartement />} />
                <Route path="/liste-Besoins/create-ressource" element={<CreateRessource />} />
                <Route path="/liste-Besoins/Envoyer" element={<Envoyer />} />
                <Route path="/liste-Besoins/Error-Envoyer" element={<ErrorEnvoyer />} />
                <Route path="/liste-Besoins/Ressource-Detail/:IdR" element={<RessourceBesoin />} />
                <Route path="/AfficherRessource/Besoin-Ordinateur " element={<OrdinateurDetails />} />
                <Route path="/AfficherRessource/Besoin-Impremente" element={< ImprimanteDetails />} />
                <Route path="/liste-appel-offers" element={<ListAppelOffreView />} />
                <Route path="/liste-appel-offers/afficher-besoin" element={<AfficherBesoins />} />
                <Route path="/liste-appel-offers/afficher-besoin/:IdB/Detail/:IdR" element={<Res_Detail_Frn />} />
                <Route path="/liste-appel-offers/afficher-besoin/create-offer" element={<CreateOffre />} />
                <Route path="/Responsable/liste-appel-offers" element={<ListeAppelsOffres />} />
                <Route path="/Responsable/liste-appel-offers/:IdB" element={<ListeBesoinResponsable />} />
                <Route path="/Responsable/liste-appel-offers/:IdB/:IdR" element={<RessourceBesoinDetail />} />
                <Route path="/liste-appel-offers/afficher-besoin/:IdB" element={<AfficherBesoins />} />
                
            </Routes>
        </BrowserRouter>
    </div>
  );
}

export default App;
