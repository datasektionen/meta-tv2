<script>
    let type = 0;
</script>

<div class="upload-box">
    <nav>
        <button>File</button>
        <button>Link to image</button>
        <button>Website</button>
    </nav>
    <div class="upload-area">
        {#if type == 0}

        {#elseif type == 1}

        {#elseif type == 2}
    </div>
</div>

<style>
    .upload-box {
        background-color: white;
        padding: 1em;
    }
</style>
