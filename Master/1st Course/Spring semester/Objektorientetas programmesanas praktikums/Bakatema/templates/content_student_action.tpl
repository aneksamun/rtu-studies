<form name="student_action" action="{$formaction}" method="POST">
	<input type="hidden" name="page" id="page" value="{$nextpage}"/>
	
	<div class="post">
		<h1 class="title">
			<a>{$status}</a>
		</h1>
		<br/>
		
		<div class="right">
			{if $mode eq edit_title}
				<div class="text">
					<b>Vēlamais tēmas nosaukums:</b><br/>
					<textarea rows="8" name="new_title" style="width:80%;">{$old_title}</textarea>
				</div>
				<button name="update_title" type="submit" value="{$title_id}">Mainīt</button>
			{/if}
			<button name="back" type="submit">Atpakaļ</button>
		</div>
	</div>
	<br/>&nbsp
</form>