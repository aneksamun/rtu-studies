<form name="student_home" action="{$formaction}" method="POST">
	<input type="hidden" name="page" id="page" value="{$nextpage}"/>
	<div class="post">
		<h1 class="title"><a>Izvēlētās tēmas stāvoklis:</a></h1>
		<br/>
		{if not $data_thesis}
			<div class="text">
				<span>Darba tēma nav izvēlēta.</span>
				<button name="select_thesis" type="submit">Izvēlēties tēmu</button>
			</div>
		{else}
			<div class="right">
				<table width="100%" cellspacing="0" cellpadding="0">
					<tbody>
						<tr class="head">
							<td>Macībspēks</td>
							<td colspan="2">Latviskais nosaukums</td>
							<td colspan="2">Nosaukums angļu valodā</td>
						</tr>
						<tr>
							<td><b>Vadītājs:</b> {$data_thesis.lecturer_name}</td>
							<td>{$data_thesis.native_title}</td>
							<td>
								<button name="edit_title" type="submit" value="{$data_thesis.title_id_n}" class="edit">&nbsp</button>
							</td>
							<td>{$data_thesis.english_title}</td>
							<td>
								<button name="edit_title" type="submit" value="{$data_thesis.title_id_e}" class="edit">&nbsp</button>
							</td>
						</tr>
						<tr>
							<td><b>Vadītāja e-pasts:</b> {$data_thesis.lecturer_email}</td>
							<td colspan="2"><b>Pēdējo izmaiņu datums:</b> {$data_thesis.revision_date_n}</td>
							<td colspan="2"><b>Pēdējo izmaiņu datums:</b> {$data_thesis.revision_date_e}</td>
						</tr>
						<tr>
							<td>&nbsp</td>
							<td colspan="2"><b>Revīzijas numurs:</b> {$data_thesis.revision_n}</td>
							<td colspan="2"><b>Revīzijas numurs:</b> {$data_thesis.revision_e}</td>
						</tr>
						<tr>
							<td>&nbsp</td>
							<td colspan="2"><b>Vadītāja apstiprinājums:</b> {if $data_thesis.lect_approved_n}Jā{else}Nē{/if}</td>
							<td colspan="2"><b>Vadītāja apstiprinājums:</b> {if $data_thesis.lect_approved_e}Jā{else}Nē{/if}</td>
						</tr>
						<tr>
							<td><b>Bak. vadītājs:</b> {$data_thesis.bach_name}</td>
							<td colspan="2"><b>Bak. vadītāja apstiprinājums:</b> {if $data_thesis.bach_approved_n}Jā{else}Nē{/if}</td>
							<td colspan="2"><b>Bak. vadītāja apstiprinājums:</b> {if $data_thesis.bach_approved_e}Jā{else}Nē{/if}</td>
						</tr>
						<tr>
							<td><b>Katedras vadītājs:</b> {$data_thesis.cath_name}</td>
							<td colspan="2"><b>Katedras vadītāja apstiprinājums:</b> {if $data_thesis.cath_approved_n}Jā{else}Nē{/if}</td>
							<td colspan="2"><b>Katedras vadītāja apstiprinājums:</b> {if $data_thesis.cath_approved_e}Jā{else}Nē{/if}</td>
						</tr>
					</tbody>
				</table>
			</div>
		{/if}
		<br/>&nbsp;
		<br/>&nbsp;
		<button name="info" type="submit" value="{$data_thesis.thesis_id}">Tēmas vēsture...</button>
		<br/>&nbsp;
	</div>
</form>