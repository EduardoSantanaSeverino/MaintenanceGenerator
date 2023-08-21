import { Component, Injector } from '@angular/core';
import { finalize } from 'rxjs/operators';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import {
	PagedListingComponentBase,
	PagedRequestDto,
} from '@shared/paged-listing-component-base';
import {
	XXXEntitySingularXXXServiceProxy,
	XXXEntitySingularXXXDto,
	XXXEntitySingularXXXDtoPagedResultDto,
} from '@shared/service-proxies/service-proxies';
import { CreateXXXEntitySingularXXXDialogComponent } from './create-XXXEntityLowerSingularXXX/create-XXXEntityLowerSingularXXX-dialog.component';
import { EditXXXEntitySingularXXXDialogComponent } from './edit-XXXEntityLowerSingularXXX/edit-XXXEntityLowerSingularXXX-dialog.component';

class PagedXXXEntityPluralXXXRequestDto extends PagedRequestDto {
	keyword: string;
	isActive: boolean | null;
}

@Component({
	templateUrl: './XXXEntityLowerPluralXXX.component.html',
	animations: [appModuleAnimation()]
})
export class XXXEntityPluralXXXComponent extends PagedListingComponentBase<XXXEntitySingularXXXDto> {
	XXXEntityLowerPluralXXX: XXXEntitySingularXXXDto[] = [];
	keyword = '';
	isActive: boolean | null;
	advancedFiltersVisible = false;

	constructor(
		injector: Injector,
		private _XXXEntityLowerSingularXXXService: XXXEntitySingularXXXServiceProxy,
		private _modalService: BsModalService
	) {
		super(injector);
	}

	list(
		request: PagedXXXEntityPluralXXXRequestDto,
		pageNumber: number,
		finishedCallback: Function
	): void {
		request.keyword = this.keyword;
		request.isActive = this.isActive;

		this._XXXEntityLowerSingularXXXService
			.getAll(
				request.keyword,
				request.isActive,
				request.skipCount,
				request.maxResultCount
			)
			.pipe(
				finalize(() => {
					finishedCallback();
				})
			)
			.subscribe((result: XXXEntitySingularXXXDtoPagedResultDto) => {
				this.XXXEntityLowerPluralXXX = result.items;
				this.showPaging(result, pageNumber);
			});
	}

	delete(XXXEntityLowerSingularXXX: XXXEntitySingularXXXDto): void {
		abp.message.confirm(
			this.l('XXXEntitySingularXXXDeleteWarningMessage', XXXEntityLowerSingularXXX.name),
			undefined,
			(result: boolean) => {
				if (result) {
					this._XXXEntityLowerSingularXXXService
						.delete(XXXEntityLowerSingularXXX.id)
						.pipe(
							finalize(() => {
								abp.notify.success(this.l('SuccessfullyDeleted'));
								this.refresh();
							})
						)
						.subscribe(() => {});
				}
			}
		);
	}

	createXXXEntitySingularXXX(): void {
		this.showCreateOrEditXXXEntitySingularXXXDialog();
	}

	editXXXEntitySingularXXX(XXXEntityLowerSingularXXX: XXXEntitySingularXXXDto): void {
		this.showCreateOrEditXXXEntitySingularXXXDialog(XXXEntityLowerSingularXXX.id);
	}

	showCreateOrEditXXXEntitySingularXXXDialog(id?: number): void {
		let createOrEditXXXEntitySingularXXXDialog: BsModalRef;
		if (!id) {
			createOrEditXXXEntitySingularXXXDialog = this._modalService.show(
				CreateXXXEntitySingularXXXDialogComponent,
				{
					class: 'modal-lg',
				}
			);
		} else {
			createOrEditXXXEntitySingularXXXDialog = this._modalService.show(
				EditXXXEntitySingularXXXDialogComponent,
				{
					class: 'modal-lg',
					initialState: {
						id: id,
					},
				}
			);
		}

		createOrEditXXXEntitySingularXXXDialog.content.onSave.subscribe(() => {
			this.refresh();
		});
	}

	clearFilters(): void {
		this.keyword = '';
		this.isActive = undefined;
		this.getDataPage(1);
	}
}
