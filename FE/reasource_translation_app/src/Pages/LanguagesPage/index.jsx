import {useEffect, useState} from "react";
import {useAPI} from "../../Hooks/UseAPI.js";
import {Col, FormControl, Row, Table} from "react-bootstrap";
import {LoadingButton} from "../../Components/LoadingButton.jsx";

function LanguagesPage() {
const {GetLocales} = useAPI();
const [locales, setLocales] = useState([]);
const [loading, setLoading] = useState(false);

    useEffect(()=>{
        fetchData();
    }, []);

    async function onAvailable(res) {
        setLocales(res.data);
    }

    async function onError(error) {
        console.log(error);
    }

    const fetchData = async () => {
        await GetLocales(onAvailable, onError);
    }

    return (
        <>
            <Row className="p-2">
                <Col>
                    <FormControl type="text" placeholder="Language Name"/>
                </Col>
                <Col>
                    <FormControl type="text" placeholder="Language Code"/>
                </Col>
                <Col>
                    <LoadingButton text = "Add" isLoading = {loading} variant = "primary" onClick = {()=>setLoading(!loading)} />
                </Col>
            </Row>

            <Table striped bordered hover className="m-2">
                <thead className="thead-dark">
                <td>Language name</td>
                <td>Language code</td>
                <td>Actions</td>
                </thead>
                <tbody>
                {locales.map((x) => (
                    <tr key={x.id}>
                        <td className="col-5">{x.name}</td>
                        <td className="col-4">{x.code}</td>
                        <td className="text-center col-3">
                            <Row>
                                <Col><LoadingButton text = "Edit" isLoading = {loading} variant = "warning" onClick = {()=>setLoading(!loading)}/></Col>
                                <Col><LoadingButton text = "Delete" isLoading = {loading} variant = "danger" onClick = {()=>setLoading(!loading)}/></Col>
                            </Row>
                        </td>
                    </tr>))}
                </tbody>
            </Table>
        </>
    )
}

export default LanguagesPage;