import {useEffect, useState} from "react";
import {useAPI} from "../../Hooks/UseAPI.js";
import {Col, FormControl, Row, Table} from "react-bootstrap";
import {LoadingButton} from "../../Components/LoadingButton.jsx";

function LanguagesPage() {
const {GetLocales, AddLanguage, DeleteLanguage} = useAPI();
const [locales, setLocales] = useState([]);
const [languageName, setLanguageName] = useState('');
const [languageCode, setLanguageCode] = useState('');
const [addLoading, setAddLoading] = useState(false);
const [deleteLoading, setDeleteLoading] = useState(false);
const [addLanguageAvailable, setLanguageAvailable] = useState({});
const [requestStatus, setRequestStatus] = useState('');
const [reqestType, setRequestType] = useState('add');

    useEffect(()=>{
        fetchData();
    }, [addLanguageAvailable]);

    const changeLanguageName = (e) =>{
        setLanguageName(e.target.value);
    }

    const changeLanguageCode = (e) =>{
        setLanguageCode(e.target.value);
    }

    async function onAvailable(res) {
        setLocales(res.data);
    }

    async function onError(error) {
        console.log(error);
    }

    const fetchData = async () => {
        await GetLocales(onAvailable, onError);
    }

    const onAddedLanguageAvailable = async (res) => {
        setAddLoading(false);
        setLanguageAvailable(res);
        setLanguageName('');
        setLanguageCode('');
    }

    const onAddedLanguageError = async (res) => {
        setAddLoading(false);
        setRequestStatus(`Error ${res.response.data.map(x=>x.ErrorMessage).join(' ')}`);
    }

    const addLanguage = async () => {

        if(languageName&&languageCode){
            switch (reqestType)
            {
                case "add":
                    setAddLoading(true);
                    setRequestStatus(``);
                    AddLanguage({"Code":languageCode, "Name":languageName}, onAddedLanguageAvailable, onAddedLanguageError);
                    break;
            }
        }
        else{
            setRequestStatus(`Error languageName and languageCode should be feel`);
        }
    }

    const onDeletedLanguageAvailable = async (res) => {
        setDeleteLoading(false);
        setLanguageAvailable(res);
    }

    const onDeletedLanguageError = async (res) => {
        setDeleteLoading(false);
        setRequestStatus(`Error ${res}`);
    }

    const deleteLanguage = async (id) => {
        setDeleteLoading(true);
        console.log(id);
        DeleteLanguage(id, onDeletedLanguageAvailable, onDeletedLanguageError);
    }

    return (
        <>
            <Row className="p-2">
                <Col>
                    <FormControl type="text" placeholder="Language Name" value={languageName} onChange={changeLanguageName}/>
                </Col>
                <Col>
                    <FormControl type="text" placeholder="Language Code" value={languageCode} onChange={changeLanguageCode}/>
                </Col>
                <Col>
                    <LoadingButton text = "Add" isLoading = {addLoading} variant = "primary" onClick = {addLanguage} />
                </Col>
            </Row>
            <Row className="p-2">
                request status: {requestStatus}
                {/*<Alert variant={alertVariant} visible={alertVisible}>*/}
                {/*    {alertMessage}*/}
                {/*</Alert>*/}
            </Row>

            <Table striped bordered hover className="m-2">
                <thead className="thead-dark">
                <tr>
                    <td>Language name</td>
                    <td>Language code</td>
                    <td>Actions</td>
                </tr>
                </thead>
                <tbody>
                {locales.map((x) => (
                    <tr key={x.id}>
                        <td className="col-5">{x.name}</td>
                        <td className="col-4">{x.code}</td>
                        <td className="text-center col-3">
                            <Row>
                                {/*<Col><LoadingButton text = "Edit" isLoading = {deleteLoading} variant = "warning" onClick = {()=>setLoading(!loading)}/></Col>*/}
                                <Col><LoadingButton text = "Delete" isLoading = {deleteLoading} variant = "danger" onClick = {async ()=>await deleteLanguage(x.id)}/></Col>
                            </Row>
                        </td>
                    </tr>))}
                </tbody>
            </Table>
        </>
    )
}

export default LanguagesPage;