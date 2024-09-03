import React, { useState, useEffect } from "react";
import ReactSelect from "react-select";

const PlanProcedureItem = ({ procedure, users }) => {
    const [selectedUsers, setSelectedUsers] = useState(null);

    const handleAssignUserToProcedure = (e) => {
        setSelectedUsers(e);
        localStorage.setItem(`selectedUsers-${procedure.procedureTitle}`, JSON.stringify(e));
    };

    const loadSelectedUsers = () => {
        const savedUsers = localStorage.getItem(`selectedUsers-${procedure.procedureTitle}`);
        if (savedUsers) {
            const parsedUsers = JSON.parse(savedUsers);
            setSelectedUsers(parsedUsers);
        }
    };

    useEffect(() => {
        loadSelectedUsers();
    });

    return (
        <div className="py-2">
            <div>
                {procedure.procedureTitle}
            </div>

            <ReactSelect
                className="mt-2"
                placeholder="Select User to Assign"
                isMulti={true}
                options={users}
                value={selectedUsers}
                onChange={(e) => handleAssignUserToProcedure(e)}
            />
        </div>
    );
};

export default PlanProcedureItem;
