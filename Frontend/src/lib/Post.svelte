<script>
    let empty = true;
    let showUploadButton = true;
    let isContentUrl = false;
    export let urlInput = "";
    export let imageInput = "";

    function toggleUploadState() {
        showUploadButton = !showUploadButton;
    }

    const handleFileUpload = (event) => {
        const file = event.target.files[0];
        if (file) {
            const reader = new FileReader();
            reader.onload = () => {
                imageInput = reader.result;
                empty = false;
                contentIsUrl = false;
            };
            reader.readAsDataURL(file);
        }

        empty = false;
        isContentUrl = false;
    };

    function submitURL() {
        empty = false;
        showUploadButton = false;
        isContentUrl = true;
    }
</script>

<span class="slide-container">
    {#if empty}
        {#if showUploadButton }
        <button on:click={toggleUploadState}>Upload content</button>
        {:else}
        <div>
            <p>Upload URL</p>
            <form on:submit|preventDefault={submitURL}>
                <input bind:value={urlInput} type="url" placeholder="URL">
                <input type="submit">
            </form>
            <br>
            <p>OR</p>
            <label for="file-upload" class="upload-btn">
                <input type="file" id="file-upload" accept=".txt,.pdf,.doc,.docx" on:change={handleFileUpload}>
            </label>
        </div>
        {/if}
        
    {:else if isContentUrl}
        <iframe title={urlInput} src={urlInput} frameborder="0"></iframe>
    {:else}
        <img src={imageInput} alt="Uploaded Image">
    {/if}
</span>

<style>
    button {
        color: #313131;
        background-color: #AAAAAA;
        width: 10em;
        height: 2em;
        font-size: 20px;
        border: none;
    }

    img {
        max-width: 100%;
        max-height: 100%;
        height: auto;
    }

    .slide-container {
        display: flex;
        justify-content: center;
        align-items: center;
        height: 11em;
        width: 20em;
        box-shadow: 
        inset 0 8px 10px -10px rgba(0, 0, 0, 0.5), /* Top */
        inset 0 -8px 10px -10px rgba(0, 0, 0, 0.2), /* Bottom */
        inset 8px 0 10px -10px rgba(0, 0, 0, 0.2), /* Right */
        inset -8px 0 10px -10px rgba(0, 0, 0, 0.2); /* Left */
        transition: filter 0.1s;
    }
    
    .slide-container:hover {
        filter: brightness(90%);
    }
</style>