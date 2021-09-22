import React, { FC } from "react";
import { observer } from 'mobx-react';
import { useStores } from '../../state';

const List: FC = observer(() => {
    const vehicles = useStores().vehicleStore.vehicles;

    return (
        <React.Fragment>
            {vehicles[0].plate}
        </React.Fragment>
    );
});

export default List;
