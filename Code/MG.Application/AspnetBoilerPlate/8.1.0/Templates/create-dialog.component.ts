import {
	Component,
	Injector,
	OnInit,
	Output,
	EventEmitter
} from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { AppComponentBase } from '@shared/app-component-base';
import {
	CreateXXXEntitySingularXXXDto,
	XXXEntitySingularXXXServiceProxy
} from '@shared/service-proxies/service-proxies';

@Component({
	templateUrl: 'create-XXXEntityLowerSingularXXX-dialog.component.html'
})
export class CreateXXXEntitySingularXXXDialogComponent extends AppComponentBase
	implements OnInit {
	saving = false;
	XXXEntityLowerSingularXXX: CreateXXXEntitySingularXXXDto = new CreateXXXEntitySingularXXXDto();

	@Output() onSave = new EventEmitter<any>();

	constructor(
		injector: Injector,
		public _XXXEntityLowerSingularXXXService: XXXEntitySingularXXXServiceProxy,
		public bsModalRef: BsModalRef
	) {
		super(injector);
	}

	ngOnInit(): void {
		this.XXXEntityLowerSingularXXX.isActive = true;
	}

	save(): void {
		this.saving = true;

		this._XXXEntityLowerSingularXXXService.create(this.XXXEntityLowerSingularXXX).subscribe(
			() => {
				this.notify.info(this.l('SavedSuccessfully'));
				this.bsModalRef.hide();
				this.onSave.emit();
			},
			() => {
				this.saving = false;
			}
		);
	}
}
