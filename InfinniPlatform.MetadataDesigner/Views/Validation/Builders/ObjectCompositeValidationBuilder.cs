﻿using System;

using InfinniPlatform.Core.Validation;
using InfinniPlatform.Core.Validation.BooleanValidators;

namespace InfinniPlatform.MetadataDesigner.Views.Validation.Builders
{
	public sealed class ObjectCompositeValidationBuilder
	{
		public ObjectCompositeValidationBuilder(string property = null)
		{
			Property = property;
		}

		public string Property { get; private set; }

		public IValidationOperator Operator { get; private set; }

		/// <summary>
		/// Добавить правило логического сложения для текущего объекта.
		/// </summary>
		public void Or(Action<ObjectValidationBuilder> buildAction)
		{
			var validationOperator = new OrValidator { Property = Property };
			buildAction(new ObjectValidationBuilder(validationOperator));

			Operator = validationOperator;
		}

		/// <summary>
		/// Добавить правило логического умножения для текущего объекта.
		/// </summary>
		public void And(Action<ObjectValidationBuilder> buildAction)
		{
			var validationOperator = new AndValidator { Property = Property };
			buildAction(new ObjectValidationBuilder(validationOperator));

			Operator = validationOperator;
		}
	}
}