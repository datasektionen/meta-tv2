// Enum-like state types
export const State = {
    preview: "preview",
    create: "create",
    edit: "edit",
    restore: "restore"
};

// Returns current time as a string in format: hh:mm
export function currentTime() {
    return (new Date())
        .getHours()
        .toLocaleString(undefined,{minimumIntegerDigits: 2}) + ":" + 
        (new Date())
        .getMinutes()
        .toLocaleString(undefined,{minimumIntegerDigits: 2});
};

// Returns current date as a string in format: yyyy-mm-dd
export function currentDate() {
    return (new Date()).toISOString().split('T')[0];
}