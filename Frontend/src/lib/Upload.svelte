<script>
    let type = 0;

    function drop(event) {
        const dt = event.dataTransfer;
        const files = dt.files;
        handleFile(files[0]);
    }

    function handleFile(file) {

    }
</script>

<div class="popup-bg">
    <div class="popup-box">
        <div id="tab-bar">
            <button 
                on:click={() => type = 0} 
                aria-current={type === 0}
            >File</button>
            <button 
                on:click={() => type = 1} 
                aria-current={type === 1}
            >Link to image</button>
            <button 
                on:click={() => type = 2} 
                aria-current={type === 2}
            >Website</button>
        </div>
        <div id="upload-area">
            {#if type == 0}
                <div>
                    <input type="file" id="file" accept="image/*,video/*,.html"/>
                    <p>Images, GIF, videos & HTML</p>
                </div>
                <div 
                    id="drop-field"
                    role="region"
                    on:drop|preventDefault|stopPropagation={drop}
                    on:dragover|preventDefault|stopPropagation
                    on:dragenter|preventDefault|stopPropagation
                ><p>Drag and drop</p></div>
            {:else if type == 1}
                <input type="text" id="image-link" placeholder="Direct link to image"/>
            {:else if type == 2}
                <input type="text" id="website" placeholder="Link to website"/>
            {/if}
        </div>
    </div>
</div>

<style>
    .popup-box {
        min-height: 15em;
        display: grid;
        grid-template-rows: auto 1fr;
    }

    #tab-bar {
        display: grid;
        grid-template-columns: 1fr 1fr 1fr;
    }

    #tab-bar > button {
        padding: 1em 4em;
        border: none;
        font-weight: bold;
        background-color: #f6f6f6;
    }

    #tab-bar > button[aria-current="true"] {
        background-color: #dadada;
        box-shadow: inset 3px 3px 5px #ccc;
    }

    #upload-area {
        margin: 2em 0 0;
        display: grid;
        grid-template-columns: 1fr 1fr 1fr;
        align-items: center;
    }

    input[type="text"] {
        display: block;
        padding: 0.8em;
        grid-column: 1 / span 3;
    }

    input[type="file"] {
        border: none;
        width: 100%;
        padding: 1em;
    }

    p {
        text-align: center;
    }

    #drop-field {
        grid-column: span 2;
        height: 100%;
        width: 100%;
        background-color: #f6f6f6;
        display: flex;
        align-items: center;
        justify-content: center;
    }

    #drop-field p {
        color: #888;
    }
</style>
