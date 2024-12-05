import {useEffect, useState} from "react";
import {useAuthProvider} from "../../Hooks/UseAuthProvider.js";
import {useNavigate} from "react-router";

function LoginPage() {
    const [login, setLogin] = useState('');
    const [password, setPassword] = useState('');
    const {signIn, checkAuth, signOut} = useAuthProvider();
    const navigate = useNavigate();

    useEffect(() => {
        signOut();
    })

    async function onSubmit(e){
        e.preventDefault();
        if(login && password)
        {
            await signIn(login, password);
            if(checkAuth())
            {
                navigate('/dashboard');
            }
            else
            {
                console.log('login failed');
            }
        }
    }

    return (
        <>
            <header>
                Resources APP
            </header>
        <form onSubmit={onSubmit}>
            <div>
                <label htmlFor="login">Login</label>
                <input id="login" type="text" placeholder="login" onChange={(e) => setLogin(e.target.value)}
                       value={login}/>
            </div>
            <div>
                <label htmlFor="password">Password</label>
                <input id="password" type="password" placeholder="Password"
                       onChange={(e) => setPassword(e.target.value)} value={password}/>
            </div>
            <button type="submit">Login</button>
        </form>
        </>
    )
}

export default LoginPage;