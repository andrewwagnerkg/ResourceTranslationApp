import React, {useEffect, useState} from "react";
import {useAuthProvider} from "../../Hooks/UseAuthProvider.js";
import {useNavigate} from "react-router";
import {
    Alert,
    Button,
    Card,
    CardBody,
    Container,
    Form,
    FormLabel,
    InputGroup,
    Nav,
    Navbar,
    Stack
} from "react-bootstrap";

function LoginPage() {
    const [login, setLogin] = useState('');
    const [password, setPassword] = useState('');
    const {signIn, checkAuth, signOut} = useAuthProvider();
    const navigate = useNavigate();
    const [showError, setShowError] = useState(false);
    const [showErrorMessage, setShowErrorMessage] = useState('');

    useEffect(() => {
        signOut();
    })

    async function onAvailableResponse()
    {
        if(checkAuth())
        {
            navigate('/dashboard');
        }
    }

    function onFaildResponse(err)
    {
        setShowError(true);
        setShowErrorMessage(err.message);
    }

    async function onSubmit(e){
        e.preventDefault();
        setShowError(false);
        if(login && password)
        {
            await signIn(login, password, onAvailableResponse, onFaildResponse);
        }
    }

    return (
        <>
            <Navbar bg="primary" data-bs-theme="dark">
                <Container>
                    <Navbar.Brand>Resources App</Navbar.Brand>
                </Container>
            </Navbar>

            <Container>
                <Stack gap={2} className="col-md-5 mx-auto vh-100 justify-content-center">
                    {showError && <Alert variant="danger" dismissible>{showErrorMessage}</Alert>}

                    <Card>
                        <CardBody>
                            <Form onSubmit={onSubmit}>
                                <Form.Group className="mb-3">
                                    <Form.Label>Login</Form.Label>
                                    <Form.Control id="login" type="text" placeholder="login" onChange={(e) => setLogin(e.target.value)}
                                                  value={login} />
                                </Form.Group>
                                <Form.Group className="mb-3">
                                    <Form.Label>Password</Form.Label>
                                    <Form.Control id="password" type="password" placeholder="Password"
                                                  onChange={(e) => setPassword(e.target.value)} value={password}/>
                                </Form.Group>
                                <Button variant="primary" type="submit">Login</Button>
                            </Form>
                        </CardBody>
                    </Card>

                </Stack>
            </Container>

        </>
    )
}

export default LoginPage;