import { Component, Injector } from '@angular/core';
import { MatDialog } from '@angular/material';
import { finalize } from 'rxjs/operators';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { PagedListingComponentBase, PagedRequestDto } from 'shared/paged-listing-component-base';
import { CampaignServiceProxy, CampaignDto, PagedResultDtoOfCampaignDto } from '@shared/service-proxies/service-proxies';
import { CreateCampaignDialogComponent } from './create-campaign/create-campaign-dialog.component';
import { EditCampaignDialogComponent } from './edit-campaign/edit-campaign-dialog.component';

class PagedModelsResultRequestDto extends PagedRequestDto {
	keyword: string;
	isActive: boolean | null;
}

@Component({
	templateUrl: './campaigns.component.html',
	animations: [appModuleAnimation()],
	styles: [
		`
		  mat-form-field {
			padding: 10px;
		  }
		`
	]
})
export class CampaignsComponent extends PagedListingComponentBase<CampaignDto> {
	campaigns: CampaignDto[] = [];
	keyword = '';
	isActive: boolean | null;

	constructor(
		injector: Injector,
		private _campaignsService: CampaignServiceProxy,
		private _dialog: MatDialog
	) {
		super(injector);
	}

	protected list(
		request: PagedModelsResultRequestDto,
		pageNumber: number,
		finishedCallback: Function
	): void {

		request.keyword = this.keyword;
		request.isActive = this.isActive;

		this._campaignsService
			.getAll(request.keyword, request.isActive, request.skipCount, request.maxResultCount)
			.pipe(
				finalize(() => {
					finishedCallback();
				})
			)
			.subscribe((result: PagedResultDtoOfCampaignDto) => {
				this.campaigns = result.items;
				this.showPaging(result, pageNumber);
			});
	}

	protected delete(campaign: CampaignDto): void {
		abp.message.confirm(
			this.l('CampaignDeleteWarningMessage', campaign.title),
			(result: boolean) => {
				if (result) {
					this._campaignsService
						.delete(campaign.id)
						.subscribe(() => { 
							abp.notify.success(this.l('SuccessfullyDeleted'));
							this.refresh();
					});
				}
			}
		);
	}

	createCampaign(): void {
		this.showCreateOrEditCampaignDialog();
	}

	editCampaign(campaign: CampaignDto): void {
		this.showCreateOrEditCampaignDialog(campaign.id);
	}

	private showCreateOrEditCampaignDialog(id?: number): void {
		let createOrEditCampaignDialog;
		if (id === undefined || id <= 0) {
			createOrEditCampaignDialog = this._dialog.open(CreateCampaignDialogComponent);
		} else {
			createOrEditCampaignDialog = this._dialog.open(EditCampaignDialogComponent, {
				data: id
			});
		}

		createOrEditCampaignDialog.afterClosed().subscribe(result => {
			if (result) {
				this.refresh();
			}
		});
	}
}
