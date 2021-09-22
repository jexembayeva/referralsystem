import * as React from 'react';
import ReactDOM from 'react-dom';
import { Router, Route, Switch, Redirect } from 'react-router';
import { createBrowserHistory } from 'history';
import { App } from './components/App';
import * as serviceWorker from './serviceWorker';
import { StoreProvider, rootStores } from './state';

const history = createBrowserHistory();

ReactDOM.render(
    <React.StrictMode>
        <StoreProvider value={rootStores}>
            <Router history={history}>
                <Switch>
                    <Route exact path='/'>
                        <App />
                    </Route>
                    <Redirect to='/' />
                </Switch>
            </Router>
        </StoreProvider>
    </React.StrictMode>,
    document.getElementById('root')
);

serviceWorker.unregister();
