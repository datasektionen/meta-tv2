<script>
    let history_entry1 = {dateTime:"2024-01-01 23:59", entry:"Some user Some text Some group"}
    let history_entry2 = {dateTime:"2024-01-01 23:59", entry:"Some other user Some more text Some other group"}

    let entries = [];

    function load_entries() {
        entries = [
            ...entries, 
        history_entry1,
        history_entry1,
        history_entry1,
        history_entry2,
        history_entry2
        ]
    }

    load_entries()
</script>

<div class="history_list">
    <h1 class="history_title">History</h1>
    {#each entries as entry}
        <div class="history_row">
            {entry.dateTime} 
            &nbsp &nbsp &nbsp
            &nbsp &nbsp &nbsp
            {entry.entry}
        </div>
    {/each}
    <button class="load_button" on:click={load_entries}>load more</button>
</div>

<style>
    .history_title {
        text-align: center;
    }
    .history_list {
        position: relative;
        width: 50%;
        margin: 0 auto;
        min-height: 38em;
    }
    .history_row {
        padding: 15px;
    }
    .load_button {
        display: block;
        padding: 0.8em 1em;
        height: 50px;
        width: 150px;
        color: white;
        background-color: #e83c84;
        border-radius: 0.5em;
        margin: 50px auto;
    }
</style>
