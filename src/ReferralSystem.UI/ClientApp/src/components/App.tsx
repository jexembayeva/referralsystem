import * as React from 'react';
import { connect } from 'react-redux';
import { IAppState } from '../state';
import { load as loadSettings } from '../state/settings/actions';
import { load as loadReferences } from '../state/references/actions';

interface IProps {
    readonly loadSettings: () => void;
}

class AppInner extends React.Component<IProps> {
    render() {
        return (
            <div>
                Единая Справочная Система
            </div>
        );
    }
}

const mapStateToProps = (state: IAppState) => ({
});

const mapDispatchToProps = (dispatch: any) => {
    console.log("dsd");
    return {
        loadSettings: () => dispatch(loadSettings()),
        loadReferences: () => dispatch(loadReferences()),
    };
};
export const App = connect(mapStateToProps, mapDispatchToProps)(AppInner);
