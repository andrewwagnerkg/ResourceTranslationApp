import React, {useEffect, useState} from "react";
import {useAPI} from "../../Hooks/UseAPI.js";
import {Button, Col, Container, Form, FormControl, Row, Table} from "react-bootstrap";

function ResourcesPage() {
const {GetResources} = useAPI();
const [locales, setLocales] = useState([]);

    useEffect(()=>{
        fetchData();
    }, []);

    async function onAvailable(res) {
        console.log("OK");
        console.log(res);
        setLocales(res.data);
    }

    async function onError(error) {
        console.log(error);
    }

    const fetchData = async () => {
        await GetResources(onAvailable, onError);
    }

    return (
        <>
            <Container>
                <Form className="mt-2">
                    <Row>
                        <Col>
                            <FormControl placeholder="name"/>
                        </Col>
                        <Col>
                            <FormControl placeholder="code"/>
                        </Col>
                        <Col>
                            <Button type="submit">Add</Button>
                        </Col>
                    </Row>
                </Form>
                <Table striped className="mt-2">
                    <thead>
                    <td>Name</td>
                    <td>Code</td>
                    <td>Actions</td>
                    </thead>
                    <tr>
                        <td>
                            RU
                        </td>
                        <td>
                            ru-RU
                        </td>
                        <td className="p-1" colSpan={2}>
                            <Button variant="primary">Edit</Button>
                        </td>
                        <td>
                            <Button variant="danger">Delete</Button>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            KG
                        </td>
                        <td>
                            ky-KG
                        </td>
                        <td colSpan={2}>
                            <Button variant="primary">Edit</Button>
                        </td>
                        <td>
                            <Button variant="danger">Delete</Button>
                        </td>
                    </tr>
                </Table>
            </Container>
        </>
    )
}

export default ResourcesPage;