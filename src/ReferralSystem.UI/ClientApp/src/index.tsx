import * as React from 'react';
import { applyMiddleware, createStore } from 'redux';
import { composeWithDevTools } from 'redux-devtools-extension';
import ReactDOM from 'react-dom';
import { Provider } from 'react-redux';
import thunk from 'redux-thunk';
import { ConnectedRouter, routerMiddleware } from 'connected-react-router';
import { Route, Switch, Redirect } from 'react-router';
import { createBrowserHistory } from 'history';
import { rootReducer } from './state';
import { App } from './components/App';
import * as serviceWorker from './serviceWorker';

const history = createBrowserHistory();

const composeEnhancers = composeWithDevTools({
    actionSanitizer: (action: any) => (
        action.type === 'References.Update' && action.payload
            ? { ...action, payload: undefined }
            : action
    )
});

let store;
if (process.env.NODE_ENV === 'development') {
    store = createStore(rootReducer(history), composeEnhancers(applyMiddleware(thunk, routerMiddleware(history))));
}
else {
    store = createStore(rootReducer(history), applyMiddleware(thunk, routerMiddleware(history)));
}

ReactDOM.render(
    <React.StrictMode>
        <Provider store={store}>
            <ConnectedRouter history={history}>
                <Switch>
                    <Route exact path='/'>
                        <App />
                    </Route>
                    <Redirect to='/' />
                </Switch>
            </ConnectedRouter>
        </Provider>
    </React.StrictMode>,
    document.getElementById('root')
);

serviceWorker.unregister();
